/*  SPDX-License-Identifier: MIT */
/*
 *  Copyright (c) 2008 Bo Berry
 *  Copyright (c) 2008-2011 Cisco Systems
 */

#include "safeclib_private.h"
#include "safe_mem_constraint.h"
#include "safe_mem_lib.h"


/**
 * NAME
 *    memcmp_s
 *
 * SYNOPSIS
 *    #include "safe_mem_lib.h"
 *    errno_t
 *    memcmp_s(const void *dest, rsize_t dmax,
 *             const void *src,  rsize_t smax, int *diff)
 *
 * DESCRIPTION
 *    Compares memory until they differ, and their difference is
 *    returned in diff.  If the block of memory is the same, diff=0.
 *
 * EXTENSION TO
 *    ISO/IEC JTC1 SC22 WG14 N1172, Programming languages, environments
 *    and system software interfaces, Extensions to the C Library,
 *    Part I: Bounds-checking interfaces
 *
 * INPUT PARAMETERS
 *    dest      pointer to memory to compare against
 *
 *    dmax      maximum length of dest, in bytess
 *
 *    src       pointer to the source memory to compare with dest
 *
 *    smax      length of the source memory block
 *
 *    *diff     pointer to the diff which is an integer greater
 *              than, equal to or less than zero according to
 *              whether the object pointed to by dest is
 *              greater than, equal to or less than the object
 *              pointed to by src.
 *
 *  OUTPUT PARAMETERS
 *    none
 *
 * RUNTIME CONSTRAINTS
 *    Neither dest nor src shall be a null pointer.
 *    Neither dmax nor smax shall be zero.
 *    dmax shall not be greater than RSIZE_MAX_MEM.
 *    smax shall not be greater than dmax.
 *
 * RETURN VALUE
 *    EOK        successful operation
 *    ESNULLP    NULL pointer
 *    ESZEROL    zero length
 *    ESLEMAX    length exceeds max limit
 *
 * ALSO SEE
 *    memcmp16_s(), memcmp32_s()
 *
 */
errno_t
memcmp_s (const void *dest, rsize_t dmax,
          const void *src,  rsize_t smax, int *diff)
{
    const uint8_t *dp;
    const uint8_t *sp;

    dp = dest;
    sp = src;

    /*
     * must be able to return the diff
     */
    if (diff == NULL) {
        invoke_safe_mem_constraint_handler("memcmp_s: diff is null",
                   NULL, ESNULLP);
        return (RCNEGATE(ESNULLP));
    }
    *diff = -1;  /* default diff */

    if (dp == NULL) {
        invoke_safe_mem_constraint_handler("memcmp_s: dest is null",
                   NULL, ESNULLP);
        return (RCNEGATE(ESNULLP));
    }

    if (sp == NULL) {
        invoke_safe_mem_constraint_handler("memcmp_s: src is null",
                   NULL, ESNULLP);
        return (RCNEGATE(ESNULLP));
    }

    if (dmax == 0) {
        invoke_safe_mem_constraint_handler("memcmp_s: dmax is 0",
                   NULL, ESZEROL);
        return (RCNEGATE(ESZEROL));
    }

    if (dmax > RSIZE_MAX_MEM) {
        invoke_safe_mem_constraint_handler("memcmp_s: dmax exceeds max",
                   NULL, ESLEMAX);
        return (RCNEGATE(ESLEMAX));
    }

    if (smax == 0) {
        invoke_safe_mem_constraint_handler("memcmp_s: smax is 0",
                   NULL, ESZEROL);
        return (RCNEGATE(ESZEROL));
    }

    if (smax > dmax) {
        invoke_safe_mem_constraint_handler("memcmp_s: smax exceeds dmax",
                   NULL, ESLEMAX);
        return (RCNEGATE(ESLEMAX));
    }

    /*
     * no need to compare the same memory
     */
    if (dp == sp) {
        *diff = 0;
        return (RCNEGATE(EOK));
    }

    /*
     * now compare sp to dp
     */
    *diff = 0;
    while (dmax > 0 && smax > 0) {
        if (*dp != *sp) {
            /***  *diff = *dp - *sp; ***/
            *diff = *dp < *sp ? -1 : 1;
            break;
        }

        dmax--;
        smax--;

        dp++;
        sp++;
    }

    return (RCNEGATE(EOK));
}
EXPORT_SYMBOL(memcmp_s)
