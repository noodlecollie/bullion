#ifndef PM_BASICTYPES_H
#define PM_BASICTYPES_H

#if !defined(__cplusplus) && !defined(__bool_true_false_are_defined)
typedef enum
{
	false,
	true
} pmboolean;
#else
typedef int pmboolean;
#endif

typedef unsigned char pmbyte;
typedef float pmvec_t;
typedef pmvec_t pmvec3_t[3];

#endif  // PM_BASICTYPES_H
