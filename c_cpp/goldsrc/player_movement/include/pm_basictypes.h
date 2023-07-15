#ifndef PM_BASICTYPES_H
#define PM_BASICTYPES_H

#if defined(__x86_64__) || defined(_WIN64)
#define X64BITS
#endif

#if !defined(__cplusplus) && !defined(__bool_true_false_are_defined)
typedef enum {false, true} pmboolean;
#else
typedef int pmboolean;
#endif

typedef unsigned char pmbyte;
typedef float pmvec_t;
typedef pmvec_t pmvec3_t[3];

typedef unsigned char uint8;
typedef signed char int8;

#if defined( _WIN32 )

typedef __int16 int16;
typedef unsigned __int16 uint16;
typedef __int32 int32;
typedef unsigned __int32 uint32;
typedef __int64 int64;
typedef unsigned __int64 uint64;

#ifdef X64BITS
typedef __int64 intp;				// intp is an integer that can accomodate a pointer
typedef unsigned __int64 uintp;		// (ie, sizeof(intp) >= sizeof(int) && sizeof(intp) >= sizeof(void *)
#else
typedef __int32 intp;
typedef unsigned __int32 uintp;
#endif

#else // _WIN32

typedef short int16;
typedef unsigned short uint16;
typedef int int32;
typedef unsigned int uint32;
typedef long long int64;
typedef unsigned long long uint64;
#ifdef X64BITS
typedef long long intp;
typedef unsigned long long uintp;
#else
typedef int intp;
typedef unsigned int uintp;
#endif

#endif // else _WIN32

#endif // PM_BASICTYPES_H
